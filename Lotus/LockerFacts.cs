using Xunit;

namespace Lotus
{
    public class LockerFacts
    {
        [Fact]
        public void should_store_one_bag()
        {
            var locker = new Locker(1);
            var bag = new Bag();
            var ticket = locker.Store(bag);
            Assert.NotNull(ticket);
            Assert.Same(bag, locker.Pick(ticket));
            Assert.Null(locker.Pick(new Ticket()));
        }

        [Fact]
        public void should_not_store_when_locker_full()
        {
            var locker = new Locker(1);
            locker.Store(new Bag());
            Assert.Throws<LockerFullException>(() => locker.Store(new Bag()));
        }
    }
}