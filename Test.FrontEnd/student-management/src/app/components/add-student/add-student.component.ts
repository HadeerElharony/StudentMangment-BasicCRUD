import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Student } from '../../models/student';
import { StudentService } from '../../services/student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css'],
})
export class AddStudentComponent {
  @ViewChild('studentForm', { static: false }) studentForm!: NgForm;

  student: Student = {
    id: 0,
    name: '',
    age: 0,
    email: '',
  };

  constructor(private studentService: StudentService) {}

  addStudent(): void {
    if (this.studentForm.valid) {
      this.studentService.createStudent(this.student).subscribe(() => {
        alert('Student added successfully!');
        this.resetForm(); // Clear the form and reset validation
      });
    }
  }

  resetForm(): void {
    this.studentForm.resetForm(); // Reset the form fields and validation state
    this.student = {
      id: 0,
      name: '',
      age: 0,
      email: '',
    };
  }
}
