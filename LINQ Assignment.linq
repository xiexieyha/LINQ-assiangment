<Query Kind="Statements">
  <Connection>
    <ID>3292de2a-71c6-4362-b3d1-cbc700b78ad6</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>University</Database>
  </Connection>
  <Reference>&lt;ProgramFilesX64&gt;\LINQPad7\LPRun7-x86.exe</Reference>
  <IncludeLinqToSql>true</IncludeLinqToSql>
  <IncludeAspNet>true</IncludeAspNet>
</Query>


#1

var pResult = Courses.GroupBy(x=> x.Title).Select(x=> new{Total = x.Count()});
pResult.Dump();



#2

var pResult = Persons.Where(x=>x.Discriminator == "Student").GroupBy(x=> x.Discriminator).Select(x=> new{Student= x.Key, Total = x.Count()});
pResult.Dump();



#3

var studentInformation = from p in Persons 
							join e in Enrollments
							on p.ID equals e.StudentID 
							join c in Courses
							on e.CourseID equals c.CourseID
							select new { p.LastName, p.FirstName, p.EnrollmentDate, c.Title};
					
					studentInformation.Dump();
					


#4

var sortedStudent = Persons.Where(x=>x.Discriminator == "Student").OrderBy(x=>x.FirstName);
sortedStudent.Dump();



#5

var sortedStudent = Persons.Where(x=>x.Discriminator == "Student").OrderByDescending(x=>x.LastName);
sortedStudent.Dump();



				
#6

var pResult = from e in Enrollments
				join p in Persons
				on e.StudentID equals p.ID
				join c in Courses
				on e.CourseID equals c.CourseID into CourseEnrollments
				from ce in CourseEnrollments.DefaultIfEmpty()
				where ce.Title != null
				select new {ce.Title, e.EnrollmentID};
pResult.Dump();		
				


#7

void Pagination( int pageSize=5, int pageNumber=1){
var pCollection = Persons.Skip(pageSize*(pageNumber-1)).Take(pageSize).Select(x=>new{x.LastName, x.FirstName});
pCollection.Dump();
}



#8

var pResult = from p in Persons
				join o in OfficeAssignments
				on p.ID equals o.InstructorID into details
				from d in details.DefaultIfEmpty()
				where p.Discriminator == "Instructor"
				select new {p.LastName, p.FirstName, d.Location};
				
pResult.Dump();		
				
								

#9

var pResult = from p in Persons
				join o in OfficeAssignments
				on p.ID equals o.InstructorID into details
				from d in details.DefaultIfEmpty()
				where p.Discriminator == "Instructor" 
				where d.Location == null
				select new {p.LastName, p.FirstName};
				
pResult.Dump();




#10

var pResult = from d in Departments
				join p in Persons
				on d.InstructorID equals p.ID into Instructors
				from i in Instructors.DefaultIfEmpty()
				select new {d.DepartmentID, d.Name,Fullname =i.FirstName + " " + i.LastName};
				
pResult.Dump();


#11
var pResult = Departments.Where(x=>x.Budget > 100000);
pResult.Dump();




