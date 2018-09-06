import { Borrower } from './borrower';

export class Credit {
    constructor(
        public id: number,
        public borrower: Borrower,
        public amount: number,
        public currency: string,
        public since: Date,
        public till: Date,
        public percentage: number

    ) { }
}