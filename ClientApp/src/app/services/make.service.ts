import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class MakeService {

    constructor(private http: HttpClient) { }

    getMakes() {
        return this.http.get('/api/makes');
    }

}
