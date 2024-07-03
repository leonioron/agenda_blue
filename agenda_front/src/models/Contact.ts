import type IContact from "@/interfaces/IContact";

export class Contact implements IContact {
    id: number
    name: string
    email: string
    phone: string

    constructor(name: string = '', email: string = '', phone: string = '', id: number = 0) {
        this.id = id
        this.name = name;
        this.email = email;
        this.phone = phone;
    }
}