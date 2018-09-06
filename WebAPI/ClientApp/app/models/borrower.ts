import { Address } from './address';

export class Borrower {
    constructor(
        public firstName: string,
        public lastName: string,
        public age: number,
        public phoneNumber: string,
        public address: Address,
        public photo: string,
        public voucher: string
    ) { }
}
