﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Credit } from '../models/credit';

@Injectable()
export class CreditsService {

    private url = "/api/credits";

    constructor(private http: HttpClient) {
    }

    getCredits() {
        return this.http.get(this.url);
    }

    getCreditById(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    saveCredit(product: Credit) {
        return this.http.post(this.url, product);
    }

    deleteCredit(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}
