using CodingChallenge.Domain;
using CodingChallenge.Domain.Constants;
using CodingChallenge.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.UI.Constants
{
    public static class Converters
    {
        public static List<Domain.Person> ConvertEmployeeToPersonList(Employee employee)
        {
            var returnList = new List<Domain.Person>();

            returnList.Add(new Domain.Person() { Name = employee.Name, Type = PersonType.Employee });

            foreach (var dependent in employee.Dependents)
            {
                returnList.Add(new Domain.Person() { Name = dependent.Name, Type = ConvertDependentTypeToPersonType(dependent.Type) });
            }

            return returnList;
        }

        public static PersonType ConvertDependentTypeToPersonType(DependentType type)
        {
            switch (type)
            {
                case DependentType.Child:
                    return PersonType.Child;
                case DependentType.Spouse:
                    return PersonType.Spouse;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
