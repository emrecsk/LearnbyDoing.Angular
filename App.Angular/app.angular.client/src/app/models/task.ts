import { Status } from './status.enum';
export interface Task {
  id?: number;
  title: string;
  description: string;
  status: Status;
  startDate: string;
  endDate: string;
}
