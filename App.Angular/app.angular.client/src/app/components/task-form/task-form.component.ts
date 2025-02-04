import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task';
import { Status } from '../../models/status.enum';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css'],
  providers: [DatePipe]
})

export class TaskFormComponent implements OnInit {
  task: Task = {
    title: '',
    description: '',
    status: Status.Pending,
    startDate: '',
    endDate: ''
  };
  isEditMode = false;
  statusKeys = Object.keys(Status).filter(key => isNaN(Number(key)));
  Status = Status;

  getEnumValue(key: string): Status {  // Helper method
    return this.Status[key as keyof typeof Status];
  }

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.taskService.getTask(Number(id)).subscribe((task) => {
        this.task = task;
        // Format dates for the input fields:
        if (this.task.startDate) {
          this.task.startDate = this.datePipe.transform(this.task.startDate, 'yyyy-MM-dd') || ''; // Handle nulls
        }
        if (this.task.endDate) {
          this.task.endDate = this.datePipe.transform(this.task.endDate, 'yyyy-MM-dd') || '';
        }
      });
    } else { // For create mode, set initial dates:
      this.task.startDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd') || '';
      this.task.endDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd') || '';
    }
  }

  saveTask(): void {
    console.log('Task before sending:', this.task);
    if (this.isEditMode) {
      this.taskService.updateTask(this.task).subscribe(() => this.router.navigate(['/']));
    } else {
      this.taskService.createTask(this.task).subscribe(() => this.router.navigate(['/']));
    }
  }

}
