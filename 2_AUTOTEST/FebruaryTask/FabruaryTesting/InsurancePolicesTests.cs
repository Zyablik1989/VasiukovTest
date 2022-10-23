using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fabruary;
using System;

namespace FabruaryTesting
{
    [TestClass]
    public class InsurancePolicesTests
    {
        [TestMethod]
        public void TestIfPoliceValidOnNextLeapYear()
        {
            //Полис выпущен в 28 февраля 2019-ого года.
            //Убеждаемся, что в високосном 2020 году он работает только в 28-ого, но и 29-ого числа
            //Если мы считаем, что полис должен работать с округлением до конца месяца.
            var policy = new InsurancePolicy(new DateTime(2019,02,28), 12);

            Assert.IsTrue(policy.IsValid(new DateTime(2020, 02, 29)));
        }
                
        [TestMethod]
        public void TestIfPoliceValidOnTimeLaterThanMidnight()
        {
            //Полис выпущен 31 января. В июле, через 6 месяцев, в месяце снова будет 31 день.
            //Убеждаемся, что весь день 31 июля, полис действителен, если мы проверяем валидность по времени.
            var policy = new InsurancePolicy(new DateTime(2022, 01, 31), 6);

            Assert.IsTrue(policy.IsValid(new DateTime(2022, 7, 31, 12, 0, 0)));
        }
    }
}
