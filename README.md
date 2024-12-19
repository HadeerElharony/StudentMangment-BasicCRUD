# Student Management System

This repository contains the code for a **Student Management System**, built with a **.NET 8 Web API** for the backend and an **Angular** frontend. The system allows you to manage student data and includes features such as adding, updating, deleting, and retrieving student records. The system interacts with a **SQL Server** database for persistent data storage.

## Features

### API (Backend)

The backend is built with .NET 8 Web API and provides the following endpoints:

1. **Get All Students**
   - **Endpoint**: `GET /api/student/getallstudents`
   - **Description**: Retrieves a list of all students.

2. **Get Student By ID**
   - **Endpoint**: `GET /api/student/getstudentbyid/{id}`
   - **Description**: Retrieves student details by ID.

3. **Get Students With Courses**
   - **Endpoint**: `GET /api/student/getstudentswithcourses`
   - **Description**: Retrieves a list of students with their associated courses.

4. **Add Student**
   - **Endpoint**: `POST /api/student/addstudent`
   - **Description**: Adds a new student to the system.

5. **Update Student**
   - **Endpoint**: `PUT /api/student/updatestudent`
   - **Description**: Updates an existing student's information.

6. **Delete Student**
   - **Endpoint**: `DELETE /api/student/deletestudent/{id}`
   - **Description**: Deletes a student by their ID.

7. **Get Student By Email**
   - **Endpoint**: `GET /api/student/getstudentbyemail?email={email}`
   - **Description**: Retrieves a student by their email address.

8. **Get Student With Courses By ID**
   - **Endpoint**: `GET /api/student/getstudentwithcoursesbyid/{id}`
   - **Description**: Retrieves student and their courses by ID.

### Frontend (Angular)

The frontend is built using Angular and provides an interface to interact with the API. It includes:

- A **form** to add and update student data.
- A **table** to display the list of all students.
- Features to **view student details**, including courses they are enrolled in.
