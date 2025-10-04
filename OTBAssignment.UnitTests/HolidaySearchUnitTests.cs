using FluentAssertions;
using OTBAssignment.Model;
using OTBAssignment.Model.Flights;
using OTBAssignment.Model.Hotels;

namespace OTBAssignment.UnitTests
{
    public class HolidaySearchUnitTests
    {

        [Test]
        public async Task HolidaySearch_WhenAskedForHolidayByCustomer1_ShouldReturnBestResultFirst()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.MAN, Airport.AGP, new DateTime(2023, 07, 01), 7);

            //Assert
            result.Should().NotBeEmpty();
            result.First().Flight.Id.Should().Be(2);
            result.First().Hotel.Id.Should().Be(9);
        }

        [Test]
        public async Task HolidaySearch_WhenAskedForHolidayByCustomer2_ShouldReturnBestResultFirst()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.LND, Airport.PMI, new DateTime(2023, 06, 15), 10);

            //Assert
            result.Should().NotBeEmpty();
            result.First().Flight.Id.Should().Be(6);
            result.First().Hotel.Id.Should().Be(5);
        }

        [Test]
        public async Task HolidaySearch_WhenAskedForHolidayByCustomer3_ShouldReturnBestResultFirst()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.ANY, Airport.LPA, new DateTime(2022, 11, 10), 14);

            //Assert
            result.Should().NotBeEmpty();
            result.First().Flight.Id.Should().Be(7);
            result.First().Hotel.Id.Should().Be(6);
        }
    }
}