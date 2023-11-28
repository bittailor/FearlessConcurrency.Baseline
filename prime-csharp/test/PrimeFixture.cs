namespace Prime;

[TestFixture]
public class PrimeFixture
{

    [Test]
    public void IsPrime()
    {
        HashSet<uint> primes = new HashSet<uint>{2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67};
        for (var i = 2u; i < 70u; i++)
        {
            Assert.That(Prime.IsPrime(i), Is.EqualTo(primes.Contains(i)));
        }
    }


    const uint UP_TO = 200000;
    const uint PRIMES = 17984;

    [Test]
    public void CountPrimes_OneThread()
    {
        Assert.That(Prime.CountPrimes(UP_TO, 1), Is.EqualTo(PRIMES));
    }

    [Test]
    public void CountPrimes_TwoThread()
    {
        Assert.That(Prime.CountPrimes(UP_TO, 2), Is.EqualTo(PRIMES));
    }

    [Test]
    public void CountPrimes_FourThread()
    {
        Assert.That(Prime.CountPrimes(UP_TO, 4), Is.EqualTo(PRIMES));
    }

    [Test]
    public void CountPrimes_MaxThread()
    {
        var maxThreads = Convert.ToUInt32(Environment.ProcessorCount);
        Assert.That(Prime.CountPrimes(UP_TO, maxThreads), Is.EqualTo(PRIMES), $"max threads is {maxThreads}");
    }
}