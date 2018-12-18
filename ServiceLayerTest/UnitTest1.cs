using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersistenceLayer;
using ServiceLayer;
using UtilityProject.Dto_Objects;

namespace ServiceLayerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_BookMovie()
        {
            IMovieServiceLayer movieServiceLayer = GetMovieService();

            bool success = movieServiceLayer.BookMovie(SetBookMovieDataDto());

            Assert.AreEqual(false,success);

        }

        [TestMethod]

        public void TestMethod_CheckSeatAvailbility()
        {
            IMovieServiceLayer movieServiceLayer = GetMovieService();

            bool success = movieServiceLayer.CheckSeatAvailbility(1,1,new TimeSpan(10,30,0));

            Assert.AreEqual(true, success);

        }

        private BookingDto SetBookMovieDataDto()
        {
            BookingDto booking = new BookingDto
            {
                Id = 1,
                CinemaId = 1,
                MovieId = 1,
                MovieTime = new TimeSpan(12, 30, 0),
                UserId = 1,
                Seats = 1
            };
            return booking;
        }

        private IMovieServiceLayer GetMovieService()
        {
            Mock<IRepository> repMock = new Mock<IRepository>();
            repMock.Setup(x => x.BookMovie(SetBookMovieDataDto()));
            repMock.Setup(x => x.CheckSeatAvailbility(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<TimeSpan>()))
                .Returns(true);
           
            IMovieServiceLayer movieServiceLayer = new MovieServiceLayer(repMock.Object);
            return movieServiceLayer;
        }

    }
}
