import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentWithCourses } from '../../models/student-with-courses';
import { StudentService } from '../../services/student.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css'],
})
export class StudentDetailsComponent implements OnInit {
  studentDetails?: StudentWithCourses;

  constructor(
    private route: ActivatedRoute,
    private studentService: StudentService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.loadStudentDetails(id);
  }

  loadStudentDetails(id: number): void {
    this.studentService.getStudentWithCourses(id).subscribe((data) => {
      this.studentDetails = data;
    });
  }
}

