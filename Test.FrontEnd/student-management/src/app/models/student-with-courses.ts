import { Course } from './course';

export interface StudentWithCourses {
  id: number;
  name: string;
  age: number;
  email: string;
  courses: Course[];
}