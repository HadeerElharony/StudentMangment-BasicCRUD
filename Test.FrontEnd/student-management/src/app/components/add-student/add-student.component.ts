import { Component } from '@angular/core';
import { Student } from '../../models/student';
import { StudentService } from '../../services/student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css'],
})
export class AddStudentComponent {
  student: Student = {
    id: 0,
    name: '',
    age: 0,
    email: '',
  };

  constructor(private studentService: StudentService) {}

  addStudent(): void {
    this.studentService.createStudent(this.student).subscribe(() => {
      alert('Student added successfully!');
      this.clearForm(); // Clear the form after successful submission
    });
  }

  clearForm(): void {
    this.student = {
      id: 0,
      name: '',
      age: 0,
      email: '',
    };
  }
}
