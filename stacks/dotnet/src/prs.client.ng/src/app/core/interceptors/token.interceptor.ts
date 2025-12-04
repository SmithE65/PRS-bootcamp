import { HttpInterceptorFn } from "@angular/common/http";
import { AuthService } from "../services/auth.service";
import { inject } from "@angular/core";

export const tokenInterceptor : HttpInterceptorFn = (req, next) => {
    const token = inject(AuthService).getAccessToken();

    const request = req.clone({
        setHeaders: {
            ...(token ? { Authorization: `Bearer ${token}` } : {})
        }
    });

    return next(request);
}