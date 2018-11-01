﻿using System;
using NUnit.Framework;

namespace Holidays.Tests {
    [TestFixture]
    public class AddingCustomHolidaysTests {
        [Test]
        public void WhenAddACustomHolidayListShouldBeIncreased() {
            var holidays = new Holidays();

            holidays.AddCustom("description", new DateTime(DateTime.Today.Year, 9, 6));

            Assert.That(holidays.List.Count, Is.EqualTo(1));
        }

        [Test]
        public void WhenCustomHolidayAlreadyIsOnTheListShouldNotBeAdded() {
            var holidays = new Holidays();

            var description = "description";
            var dateTime = new DateTime(DateTime.Today.Year, 1, 1);

            holidays.AddCustom(description, dateTime);
            holidays.AddCustom(description, dateTime);

            Assert.That(holidays.List.Count, Is.EqualTo(1));
        }

        [Test]
        public void WhenAddACustomHolidayListShouldBeKeepOrdered() {
            var holidays = new Holidays();

            holidays.AddCustom("description1", new DateTime(DateTime.Today.Year, 2, 6));
            holidays.AddCustom("description2", new DateTime(DateTime.Today.Year, 9, 6));
            holidays.AddCustom("description3", new DateTime(DateTime.Today.Year, 3, 6));
            holidays.AddCustom("description4", new DateTime(DateTime.Today.Year, 3, 1));

            var holidaysList = holidays.List;

            for (var i = 1; i < holidaysList.Count - 1; i++) {
                Assert.That(holidaysList[i], Is.GreaterThan(holidaysList[i - 1]));
            }
        }
    }
}