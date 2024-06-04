using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EmployeeDL
    {
        private readonly DatabaseContext _context;

        public EmployeeDL()
        {
            _context = new DatabaseContext();
        }

        public List<EmployeeDTO> GetEmployees()
        {
            var employees = _context.GetContext().Employees.ToList();
            return Mapper.convertToList(employees);
        }

        public void Save(EmployeeDTO eDTO)
        {
            var emp = _context.GetContext().Employees.Find(eDTO.EmployeeID);
            if (emp != null)
            {
                emp.FirstName = eDTO.FirstName;
                emp.LastName = eDTO.LastName;
                emp.Title = eDTO.Title;
                emp.TitleOfCourtesy = eDTO.TitleOfCourtesy;
                emp.BirthDate = eDTO.BirthDate;
                emp.HireDate = eDTO.HireDate;

                _context.GetContext().SaveChanges();
            }
        }

        public void Insert(EmployeeDTO eDTO)
        {
            var emp = Mapper.MapToEntity(eDTO);
            _context.GetContext().Employees.Add(emp);
            _context.GetContext().SaveChanges();
        }

        public void Delete(int empId)
        {
            var emp = _context.GetContext().Employees.Find(empId);
            if (emp != null)
            {
                _context.GetContext().Employees.Remove(emp);
                try
                {
                    _context.GetContext().SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public void InsertList(List<EmployeeDTO> emps)
        {
            foreach (var e in emps)
            {
                Insert(e);
            }
        }
    }
}
