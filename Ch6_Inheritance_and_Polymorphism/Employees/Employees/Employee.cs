using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee
    {
        public class BenefitsPackage
        {
            public enum BenefitPackageLevel
            { Standard, Gold, Platinum }

            // Assume members that represent
            // dental/health benefits, and so on
            public double ComputePayDeduction()
            {
                return 125.0;
            }
        }
        // static data
        private static double bonusRate = 0.85;
        // Field data
        protected string empName;
        protected int empAge;
        protected string empSSN;
        protected int empID;
        protected float currPay;
        protected BenefitsPackage empBenefits = new BenefitsPackage();
    }
}
