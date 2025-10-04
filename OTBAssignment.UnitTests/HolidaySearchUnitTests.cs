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
            var holidaySearch = new HolidaySearch("MAN", "AGP", "2023/07/01", 7);

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
            var holidaySearch = new HolidaySearch("string_for_london_airports", "PMI", "2023/06/15", 10);

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
            var holidaySearch = new HolidaySearch("string_for_any_airport", "LPA", "2022/11/10", 14);

            //Act
            var result = await holidaySearch.GetResults();

            //Assert
            result.Should().NotBeEmpty();
            result.First().Flight.Id.Should().Be(7);
            result.First().Hotel.Id.Should().Be(6);
        }
    }
}