cmake_minimum_required(VERSION 3.14)
if (CMAKE_VERSION VERSION_GREATER_EQUAL "3.24.0")
    cmake_policy(SET CMP0135 NEW)
endif()

project(prime)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
add_compile_options(-Wall -Wextra -Wpedantic)

find_package( Threads REQUIRED )

include(FetchContent)
FetchContent_Declare(
  googletest
  URL https://github.com/google/googletest/archive/f8d7d77c06936315286eb55f8de22cd23c188571.zip
)
set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
FetchContent_MakeAvailable(googletest)

add_library(
  prime_lib
  src/prime.cpp
)

target_include_directories( prime_lib PUBLIC src)

add_executable(
  prime
  bin/main.cpp
)

target_link_libraries(
  prime
  prime_lib
  ${CMAKE_THREAD_LIBS_INIT}
)

enable_testing()

add_executable(
  prime_test
  test/prime_test.cpp
)

target_link_libraries(
  prime_test
  prime_lib
  GTest::gtest_main
  ${CMAKE_THREAD_LIBS_INIT}
)

include(GoogleTest)
gtest_discover_tests(prime_test)