import { Component,HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { StudentService } from '../../services/student.service';
import { Student } from '../../models/student';

@Component({
  selector: 'app-student-list-with-context-menu',
  templateUrl: './student-list-with-context-menu.component.html',
  styleUrls: ['./student-list-with-context-menu.component.css'],
})
export class StudentListWithContextMenuComponent {
  students: Student[] = [];
  loading: boolean = true;
  showUpdateModal: boolean = false;
  selectedStudent: Student = {} as Student;

  constructor(private studentService: StudentService, private router: Router) {}

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(): void {
    this.loading = true;
    this.studentService.getStudents().subscribe({
      next: (data) => {
        this.students = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading students:', err);
        this.loading = false;
      },
    });
  }

  viewDetails(studentId: number): void {
    this.router.navigate(['/students', studentId]);
  }

  deleteStudent(studentId: number): void {
    if (confirm('Are you sure you want to delete this student?')) {
      this.studentService.deleteStudent(studentId).subscribe({
        next: () => {
          alert('Student deleted successfully.');
          this.loadStudents();
        },
        error: (err) => {
          console.error('Error deleting student:', err);
          alert('Failed to delete student.');
        },
      });
    }
  }

  addStudent(): void {
    this.router.navigate(['/add-student']);
  }


  openUpdateModal(student: Student): void {
    this.selectedStudent = { ...student }; // Clone the student object
    this.showUpdateModal = true;
  }

  closeUpdateModal(): void {
    this.showUpdateModal = false;
    this.selectedStudent = {} as Student; // Reset selectedStudent
  }

  updateStudent(): void {
    this.studentService.updateStudent(this.selectedStudent.id, this.selectedStudent).subscribe({
      next: () => {
        this.loadStudents();
        this.closeUpdateModal();
      },
      error: (err) => {
        alert('Failed to update student.');
        console.error(err);
      }
    });
  }

}