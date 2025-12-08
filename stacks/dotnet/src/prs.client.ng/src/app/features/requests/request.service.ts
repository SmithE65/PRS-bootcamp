import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class RequestService {
    private readonly base = '/api';
    private readonly http = inject(HttpClient);
}