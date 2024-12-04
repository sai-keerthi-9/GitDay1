use assignments

--1.	Write a query to display your birthday( day of week)

select DATENAME(weekday,'2002-07-09') as Birthday     


--2.	Write a query to display your age in days
select DATEDIFF(DAY,'2002-07-09',getdate()) as AGE

--3.	Write a query to display all employees information those who joined before 5 years in the current month

select * from Employee where Hire_date <=DATEADD(year,-5,getdate()) and month(Hire_date)=month(getdate())
 

--4.transaction
begin tran
create table Employee2
(
 Empno  int primary key,
 Ename varchar(20) ,
 Salary bigint,
 doj date,
 )
 select * from Employee2
 insert into Employee2 values(1,'keerthi',30000,'2024-10-16'),
 (2,'Meghana',28000,'2024-09-10'),
 (3,'Bhavani',35000,'2023-11-22')

 update Employee2 set Salary=Salary+Salary*0.15 where Empno=2

 save tran t1

 delete from Employee2 where Empno=1

 rollback tran t1






 --user defined function

create Function Calculated_Bonus                
(
  @deptno int,
  @sal decimal(18,2)
  )
  returns decimal(18,2)
  as 
  begin
  declare @Bonus float;
  if  @deptno=10
     set  @bonus=@sal*0.15;
  else if @deptno=20
     set @bonus=@sal*0.20;
  else
       set @bonus=@sal*0.05;
  return @bonus;
  end;

select EmpNo, EmpName, dbo.Calculated_Bonus(deptno,Salary) as BONUS from Employee

 


--6. Create a procedure to update the salary of employee by 500 
--whose dept name is Sales and current salary is below 1500 (use emp table)


insert into EMP1
values (7369, 'SMITH', 'CLERK', 7902, '17-DEC-80' , 800 ,null ,20),
	   (7499,'ALLEN','SALESMAN',7698, '20-FEB-81', 1600,300 ,30),
		(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500 , 30),
		(7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975,null, 20),
		(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250,1400, 30),
		(7698, 'BLAKE','MANAGER',7839, '01-MAY-81', 2850 ,null,30),
		(7782, 'CLARK','MANAGER', 7839, '09-JUN-81', 2450 ,null, 10),
		(7788,'SCOTT','ANALYST', 7566 ,'19-APR-87',3000, null, 20),
		(7839, 'KING','PRESIDENT',null,'17-NOV-81',5000 ,null,10),
		(7844, 'TURNER','SALESMAN',7698, '08-SEP-81',1500, 0, 30),
		(7876, 'ADAMS', 'CLERK', 7788,'23-MAY-87', 1100,null, 20),
		(7900, 'JAMES', 'CLERK', 7698,'03-DEC-81',950,null, 30),
		(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81',3000,null, 20),
		(7934, 'MILLER', 'CLERK', 7782, '23-JAN-82',1300,null, 10)
create or alter proc Update_salary
as
begin
  update Emp1 set Sal=Sal+500 where DeptNo=(select DeptNo from Department where DName='Sales') 
  and Sal<1500
  end

exec Update_salary 
 
select * from Emp1
select * from Department
