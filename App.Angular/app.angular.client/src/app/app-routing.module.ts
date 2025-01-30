import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewPageComponent } from './new-page/new-page.component'

const routes: Routes = [
  { path: 'new-page', component: NewPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
