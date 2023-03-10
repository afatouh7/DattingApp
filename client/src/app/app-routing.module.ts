import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_gards/auth.guard';

const routes: Routes = [
{path:'',component:HomeComponent},
{
  path:'',
  runGuardsAndResolvers:'always',
  canActivate:[AuthGuard],
  children:[
    {path:'members',component:MemberListComponent,canActivate:[AuthGuard]},
    {path:'members/:username',component:MemberDetailsComponent},
    {path:'lists',component:ListsComponent},
    {path:'messages',component:MessagesComponent},
  ]
},
{path:'errors',component:TestErrorsComponent},
{path:'**',component:HomeComponent,pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
