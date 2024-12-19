import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentListWithContextMenuComponent } from './student-list-with-context-menu.component';

describe('StudentListWithContextMenuComponent', () => {
  let component: StudentListWithContextMenuComponent;
  let fixture: ComponentFixture<StudentListWithContextMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentListWithContextMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentListWithContextMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
