using FluentAssertions;
using OTBAssignment.Model;

namespace OTBAssignment.UnitTests
{
    public class HolidaySearchUnitTests
    {

        [Test]
        public async Task HolidaySearch_WhenAskedForHolidayByCustomer1_ShouldReturnBestResultFirst()
        {
            //Arrange
            var holidaySearch = new HolidaySearch(Airport.MAN, Airport.AGP, new DateTime(2023, 07, 01), 7);

            //Act
            var result = await holidaySearch.GetResults();

            //Assert
            result.Should().NotBeEmpty();
            result.First().Flight.Id.Should().Be(2);
            result.First().Hotel.Id.Should().Be(9);
        }

        [Test]
        public async Task HolidaySearch_WhenAskedForHolidayByCustomer2_ShouldReturnBestResultFirst()
        {
            //Arrange
            var holidaySearch = new HolidaySearch(Airport.LND, Airport.PMI, new DateTime(2023, 06, 15), 10);

            //Act
            var result = await holidaySearch.GetResults();

            //Assert
            result.Should().NotBeEmpty();
            result.First().Flight.Id.Should().Be(6);
            result.First().Hotel.Id.Should().Be(5);
        }

        [Test]
        public async Task HolidaySearch_WhenAskedForHolidayByCustomer3_ShouldReturnBestResultFirst()
        {
            //Arrange
            var holidaySearch = new HolidaySearch(Airport.ANY, Airport.LPA, new DateTime(2022, 11, 10), 14);

            //Act
            var result = await holidaySearch.GetResults();

            //Assert
            result.Should().NotBeEmpty();
            result.First().Flight.Id.Should().Be(7);
            result.First().Hotel.Id.Should().Be(6);
        }
    }
}