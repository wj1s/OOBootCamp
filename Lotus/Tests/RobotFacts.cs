using Lotus.Exceptions;
using Lotus.LockerFinders;
using Lotus.Model;
using Xunit;

namespace Lotus.Tests
{
    public class RobotFacts
    {
        [Fact]
        public void should_manage_lockers()
        {
            var robot = Robot.CreateFifoRobot(new[] {new Locker(1), new Locker(1)});
            Assert.NotNull(robot);
        }

        [Fact]
        public void should_store_a_bag_with_robot()
        {
            var locker = new Locker(1);
            var bag = new Bag();
            Ticket ticket = Robot.CreateFifoRobot(new[] {locker}).Store(bag);
            Assert.Same(bag, locker.Pick(ticket));
        }

        [Fact]
        public void should_store_multi_bag_in_one_locker()
        {
            var locker = new Locker(2);
            var robot = Robot.CreateFifoRobot(new[] {locker});

            var bag1 = new Bag();
            Ticket ticket1 = robot.Store(bag1);
            var bag2 = new Bag();
            Ticket ticket2 = robot.Store(bag2);

            Assert.Same(bag1, locker.Pick(ticket1));
            Assert.Same(bag2, locker.Pick(ticket2));
        }

        [Fact]
        public void should_store_multi_bag_in_multi_locker()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = Robot.CreateFifoRobot(new[] {locker1, locker2});

            var bag1 = new Bag();
            Ticket ticket1 = robot.Store(bag1);
            var bag2 = new Bag();
            Ticket ticket2 = robot.Store(bag2);

            Assert.Same(bag1, locker1.Pick(ticket1));
            Assert.Same(bag2, locker2.Pick(ticket2));
        }

        [Fact]
        public void should_throw_exception_when_all_locker_full_when_store_bag()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = Robot.CreateFifoRobot(new[] {locker1, locker2});

            robot.Store(new Bag());
            robot.Store(new Bag());
            Assert.Throws<LockerFullException>(() => robot.Store(new Bag()));
        }

        [Fact]
        public void should_throw_exception_when_all_locker_full_when_no_cell()
        {
            Assert.Throws<LockerFullException>(() => Robot.CreateFifoRobot(new[] {new Locker(0), new Locker(0)}).Store(new Bag()));
        }

        [Fact]
        public void should_throw_exception_when_robot_with_no_cell_when_store_bag()
        {
            Assert.Throws<ZeroLockerException>(() => Robot.CreateFifoRobot(null).Store(new Bag()));
            Assert.Throws<ZeroLockerException>(() => Robot.CreateFifoRobot(new Locker[0]).Store(new Bag()));
        }

        [Fact]
        public void should_pick_bag_by_correct_ticket()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = Robot.CreateFifoRobot(new[] {locker1, locker2});

            var bag1 = new Bag();
            Ticket ticket1 = robot.Store(bag1);
            var bag2 = new Bag();
            Ticket ticket2 = robot.Store(bag2);

            Assert.Same(bag1, robot.Pick(ticket1));
            Assert.Same(bag2, robot.Pick(ticket2));
        }

        [Fact]
        public void should_not_repick_bag_with_one_ticket()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = Robot.CreateFifoRobot(new[] {locker1, locker2});

            Ticket ticket = robot.Store(new Bag());

            Assert.NotNull(robot.Pick(ticket));
            Assert.Null(robot.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_bag_by_wrong_ticket()
        {
            var locker1 = new Locker(1);
            var locker2 = new Locker(1);
            var robot = Robot.CreateFifoRobot(new[] {locker1, locker2});

            robot.Store(new Bag());
            robot.Store(new Bag());

            Assert.Null(robot.Pick(new Ticket()));
        }
    }
}