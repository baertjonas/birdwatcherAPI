import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AanmeldenComponent } from './aanmelden/aanmelden.component';
import { VogelsComponent } from './vogels/vogels.component';
import { WaarnemingenComponent } from './waarnemingen/waarnemingen.component';
import { SpottersComponent } from './spotters/spotters.component';

const routes: Routes = [
  { path: '', component: AanmeldenComponent },
  { path: 'aanmelden', component: AanmeldenComponent },
  { path: 'waarnemingen', component: WaarnemingenComponent},
  { path: 'vogels', component: VogelsComponent },
  { path: 'spotters', component: SpottersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
