import { Component, OnInit } from '@angular/core';
import { CreditsService } from './services/credits.service';
import { Credit } from './models/credit';
import { Borrower } from './models/borrower';
import { Address } from './models/address';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [CreditsService]
})
export class AppComponent implements OnInit {
    
    credit: Credit;
    credits: Credit[];
    tableMode: boolean = true;

    constructor(private creditsService: CreditsService) {
        this.credit = new Credit(0, new Borrower("", "", 0, "", new Address("", "", "", "", "", ""), "", ""), 0, "", null, null, 0);
    }

    ngOnInit() {
        this.loadCredits();
    }

    loadCredits(): void {
        this.creditsService.getCredits()
            .subscribe((data: Credit[]) => this.credits = data);
    }

    save(): void {
        if (this.credit.id == null) {
            this.creditsService.saveCredit(this.credit)
                .subscribe((data: Credit) => this.credits.push(data));
        } else {
            this.creditsService.saveCredit(this.credit)
                .subscribe(data => this.loadCredits());
        }
        this.cancel();
    }

    cancel(): void {
        this.credit = new Credit(0, new Borrower("", "", 0, "", new Address("", "", "", "", "", ""), "", ""), 0, "", null, null, 0);
        this.tableMode = true;
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }

    editCredit(c: Credit): void {
        this.credit = c;
    }

    delete(c: Credit) {
        this.creditsService.deleteCredit(c.id)
            .subscribe(data => this.loadCredits());
    }
}
