using FluentAssertions;
using OTBAssignment.Model;
using OTBAssignment.Model.Flights;
using OTBAssignment.Model.Hotels;

namespace OTBAssignment.UnitTests
{
    public class HolidaySearchUnitTests
    {
        [Test]
        public async Task HolidaySearch_WhenHavingResults_ShouldGiveAllData()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.MAN, Airport.AGP, new DateTime(2023, 07, 01), 7);

            //Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(1);
            // 83*7+245 = 826
            result.First().TotalPrice.Should().Be(826);
            result.First().Flight.Id.Should().Be(2);
            result.First().Flight.DepartingFrom.Should().Be("MAN");
            result.First().Flight.TravelingTo.Should().Be("AGP");
            result.First().Flight.Price.Should().Be(245);
            result.First().Hotel.Id.Should().Be(9);
            result.First().Hotel.Name.Should().Be("Nh Malaga");
            result.First().Hotel.PricePerNight.Should().Be(83);
            // 83*7 = 581
            result.First().Hotel.TotalPrice.Should().Be(581);
        }

        [Test]
        public async Task HolidaySearch_WhenHavingOneResult_ShouldReturnBestResultFirst()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.MAN, Airport.AGP, new DateTime(2023, 07, 01), 7);

            //Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(1);
            result.First().Flight.Id.Should().Be(2);
            result.First().Hotel.Id.Should().Be(9);
        }

        [Test]
        public async Task HolidaySearch_WhenHavingFourResults_ShouldReturnBestResultFirst()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.LND, Airport.PMI, new DateTime(2023, 06, 15), 10);

            //Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(4);
            result.First().Flight.Id.Should().Be(6);
            result.First().Hotel.Id.Should().Be(5);
        }

        [Test]
        public async Task HolidaySearch_WhenAskingForAnyAirport_ShouldReturnBestResultFirst()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.ANY, Airport.LPA, new DateTime(2022, 11, 10), 14);

            //Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(1);
            result.First().Flight.Id.Should().Be(7);
            result.First().Hotel.Id.Should().Be(6);
        }

        [Test]
        public async Task HolidaySearch_WhenAskingForAnyNotCompatibleData_ShouldReturnEmptyResult()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.ANY, Airport.LPA, new DateTime(2025, 11, 10), 14);

            //Assert
            result.Should().BeEmpty();
        }

        [Test]
        public async Task HolidaySearch_WhenHavingMultipleOptionsFromSameAirport_ShouldReturnBestResultFirst()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.MAN, Airport.ANY, new DateTime(2023, 07, 01), 7);

            //Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(2);
            result.First().Flight.Id.Should().Be(2);
            result.First().Hotel.Id.Should().Be(9);
        }

        [Test]
        public async Task HolidaySearch_WhenLookingForAnyAirports_ShouldReturnBestResultFirst()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.ANY, Airport.ANY, new DateTime(2023, 07, 01), 7);

            //Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(4);
            result.First().Flight.Id.Should().Be(11);
            result.First().Hotel.Id.Should().Be(9);
        }

        [Test]
        public async Task HolidaySearch_WhenLookingForHotelWithDuplicateData_ShouldPickSmallerId()
        {
            //Arrange
            var flightProvider = new JsonFlightsProvider();
            var hotelProvider = new JsonHotelProvider();
            var holidaySearch = new HolidaySearch(flightProvider, hotelProvider);

            //Act
            var result = await holidaySearch.GetResults(Airport.ANY, Airport.PMI, new DateTime(2023, 06, 15), 14);

            //Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(8);
            result.First().Flight.Id.Should().Be(6);
            result.First().Hotel.Id.Should().Be(3);
        }
    }
}