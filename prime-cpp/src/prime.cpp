#include "prime.hpp"

#include <algorithm>
#include <iostream>
#include <string>
#include <thread>
#include <vector>

bool is_prime(uint32_t n) {
    for (uint32_t i = 2; i <= n / 2; ++i) {
        if (n % i == 0)
            return false;
    }
    return true;
}

uint32_t count_primes_no_threads(uint32_t upTo) {
    uint32_t numberOfPrimeNumbers = 0;
    uint32_t currentNumber = 2;

    while(currentNumber < upTo){
        if (is_prime(currentNumber++)) ++numberOfPrimeNumbers;    
    }
    return numberOfPrimeNumbers;
}

uint32_t count_primes(uint32_t upTo, uint32_t numberOfThreads) {
    std::vector<std::thread> threads;
    uint32_t numberOfPrimeNumbers = 0;
    uint32_t currentNumber = 2;

    for (uint32_t t = 0; t < numberOfThreads; t++) {
        threads.emplace_back([&numberOfPrimeNumbers, &currentNumber, upTo]() {
            while(true){
                uint32_t localCurrentNumber = currentNumber++; 
                if(localCurrentNumber >= upTo) {
                    break;
                }
                if (is_prime(localCurrentNumber)) ++numberOfPrimeNumbers;    
            }
        });    
    }

    std::for_each(threads.begin(), threads.end(), [](auto& t){t.join();});
    return numberOfPrimeNumbers;
}
