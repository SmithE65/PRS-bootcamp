import { Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';

export const routes: Routes = [
	{
		path: '',
		loadComponent: () => import('./features/dashboard/dashboard.component').then((m) => m.DashboardComponent),
		canActivate: [AuthGuard],
	},
	{
		path: 'login',
		loadComponent: () => import('./features/login/login.component').then((m) => m.LoginComponent),
	},
	{
		path: '**',
		redirectTo: ''
	}
];
