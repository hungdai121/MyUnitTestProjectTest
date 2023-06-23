using MyUnitTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTestProject1.Theory
{
    public class UserTheoryData: TheoryData<User>
    {
        public UserTheoryData()
        {
            /**
             * Each item you add to the TheoryData collection will try to pass your unit test's one by one.
             */
            Add(new User { Id = 1, Name = "Hung", Age = 24, Nation = "VietNam" });
            Add(new User { Id = 8, Name = "Alex", Age = 11, Nation = "England" });
            Add(new User { Id = 9, Name = "Along", Age = 99, Nation = "Ailen" });
        }
    }
}
