using System;
using HumanResources.Domain.Entities;
using Xunit;

namespace HumanResources.Domain.Tests.Entities
{
    public class EmployeeTests
    {
        private readonly Employee _emp;

        public EmployeeTests()
        {
            _emp = new Employee(Role.Qa, "Peter", "Quinn");
        }

        [Fact]
        public void Constructor_WhenPassSurnameName_InstanceHasValues()
        {
            var emp1 = new Employee(Role.BusinessAnalyst, "Quinn", "Peter");
            Assert.Equal("Peter", emp1.Name);
            Assert.Equal("Quinn", emp1.Surname);
            Assert.Equal(Role.BusinessAnalyst, emp1.Role);
        }

        [Fact]
        public void UpdateContactInfo_WhenPassInfo_InstanceHasValues()
        {
            var contactInfo = new ContactInfo("n@gmail.com", "12345");

            _emp.UpdateContactInfo(contactInfo);

            Assert.Equal("n@gmail.com", _emp.Email);
            Assert.Equal("12345", _emp.Cell);
        }

        [Fact]
        public void UpdateContactInfo_WhenPassNullInfo_ThrowsException()
        { 
            Assert.Throws<ArgumentNullException>(() => _emp.UpdateContactInfo(null));
        }

        [Fact]
        public void MarkAsEmployed_WhenCalled_IsEmployedIsTrue()
        {
            _emp.MarkAsEmployed();

            Assert.True(_emp.IsEmployed);
        }

        [Fact]
        public void MarkAsUnemployed_WhenCalled_IsEmployedIsFalse()
        {
            _emp.MarkAsUnemployed();

            Assert.False(_emp.IsEmployed);
        }
    }
}
