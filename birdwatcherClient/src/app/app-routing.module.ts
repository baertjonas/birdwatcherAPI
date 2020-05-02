import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AanmeldenComponent } from './aanmelden/aanmelden.component';
import { VogelsComponent } from './vogels/vogels.component';

const routes: Routes = [
  { path: '', component: AanmeldenComponent },
  { path: 'aanmelden', component: AanmeldenComponent },
  { path: 'waarnemingen', component: VogelsComponent},
  { path: 'vogels', component: VogelsComponent },
  { path: 'spotters', component: VogelsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
