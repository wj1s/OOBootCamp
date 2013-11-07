using Xunit;

namespace Lotus
{
    public class RobotFacts
    {
        [Fact]
        public void should_manage_lockers()
        {
            var robot = new Robot(new[] {new Locker(1), new Locker(1)});
            Assert.NotNull(robot);
        }

        [Fact]
        public void should_store_a_bag_with_robot()
        {
            var locker = new Locker(1);
            var bag = new Bag();
            var ticket = new Robot(new[] {locker}).Store(bag);
            Assert.Same(bag, locker.Pick(ticket));
        }

        [Fact]
        public void should_store_multi_bag_in_one_locker()
        {
            var locker = new Locker(2);
            var robot = new Robot(new[] {locker});

            var bag1 = new Bag();
            var ticket1 = robot.Store(bag1);
            var bag2 = new Bag();
            var ticket2 = robot.Store(bag2);

            Assert.Same(bag1, locker.Pick(ticket1));
            Assert.Same(bag2, locker.Pick(ticket2));
        }

        [Fact]
        public void should_store_multi_bag_in_multi_locker()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = new Robot(new[] {locker1, locker2});

            var bag1 = new Bag();
            var ticket1 = robot.Store(bag1);
            var bag2 = new Bag();
            var ticket2 = robot.Store(bag2);

            Assert.Same(bag1, locker1.Pick(ticket1));
            Assert.Same(bag2, locker2.Pick(ticket2));
        }

        [Fact]
        public void should_throw_exception_when_all_locker_full_when_store_bag()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = new Robot(new[] { locker1, locker2 });

            robot.Store(new Bag());
            robot.Store(new Bag());
            Assert.Throws<LockerFullException>(() => robot.Store(new Bag()));
        }

        [Fact]
        public void should_pick_bag_by_correct_ticket()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = new Robot(new[] { locker1, locker2 });

            var bag1 = new Bag();
            var ticket1 = robot.Store(bag1);
            var bag2 = new Bag();
            var ticket2 = robot.Store(bag2);

            Assert.Same(bag1, robot.Pick(ticket1));
            Assert.Same(bag2, robot.Pick(ticket2));
        }
        
        [Fact]
        public void should_not_repick_bag_with_one_ticket()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = new Robot(new[] { locker1, locker2 });

            var ticket = robot.Store(new Bag());

            Assert.NotNull(robot.Pick(ticket));
            Assert.Null(robot.Pick(ticket));
        }
        
        [Fact]
        public void should_not_pick_bag_by_wrong_ticket()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = new Robot(new[] { locker1, locker2 });

            robot.Store(new Bag());
            robot.Store(new Bag());

            Assert.Null(robot.Pick(new Ticket()));
        }
    }
}