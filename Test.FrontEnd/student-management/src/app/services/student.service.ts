import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from '../models/student';
import { StudentWithCourses } from '../models/student-with-courses';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  api_url: string = `${environment.apiBaseUrl}/Student`;

  constructor(private http: HttpClient) {}

  // Get all students
  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.api_url}/GetAllStudents`);
  }

  // Get a specific student along with their courses
  getStudentDetails(id: number): Observable<StudentWithCourses> {
    return this.http.get<StudentWithCourses>(`${this.api_url}/GetStudentById/${id}`);
  }

  // Get all students with their courses
  getStudentsWithCourses(): Observable<StudentWithCourses[]> {
    return this.http.get<StudentWithCourses[]>(`${this.api_url}/GetStudentsWithCourses`);
  }

  // Get all students with their courses
  getStudentWithCourses(id: number): Observable<StudentWithCourses> {
      return this.http.get<StudentWithCourses>(`${this.api_url}/GetStudentWithCoursesById/${id}`);
    }

  // Create a new student
  createStudent(student: Student): Observable<Student> {
    return this.http.post<Student>(`${this.api_url}/AddStudent`, student);
  }

  // Update a student's information
  updateStudent(id: number, student: Student): Observable<void> {
    return this.http.put<void>(`${this.api_url}/UpdateStudent`, student);
  }

  // Delete a student
  deleteStudent(id: number): Observable<void> {
    return this.http.delete<void>(`${this.api_url}/DeleteStudent/${id}`);
  }
}
