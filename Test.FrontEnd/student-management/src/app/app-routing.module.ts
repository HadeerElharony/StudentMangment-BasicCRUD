import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentListComponent } from './components/student-list/student-list.component';
import { StudentDetailsComponent } from './components/student-details/student-details.component';
import { AddStudentComponent } from './components/add-student/add-student.component';
import { StudentListWithContextMenuComponent } from './components/student-list-with-context-menu/student-list-with-context-menu.component';

const routes: Routes = [
  { path: '', redirectTo: '/students', pathMatch: 'full' },
  { path: 'students', component: StudentListWithContextMenuComponent },
  { path: 'add-student', component: AddStudentComponent },
  // { path: '', component: StudentListWithContextMenuComponent },

  // // { path: '', component: StudentListComponent },
  // { path: 'students/:id', component: StudentDetailsComponent },
  // { path: 'add-student', component: AddStudentComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
