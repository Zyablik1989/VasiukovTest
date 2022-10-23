1) SELECT * FROM Employees WHERE LOWER(emp_name)  like '%m%'

2) SELECT Employees.dept_id, MAX(Employees.salary) as Max_Salary FROM Employees GROUP BY Employees.dept_id

3) SELECT emp_name, salary FROM Employees WHERE salary IN
    (SELECT salary FROM Employees GROUP BY salary HAVING COUNT(*)>1)
		ORDER BY salary