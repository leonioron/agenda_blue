import type IContact from "@/interfaces/IContact";
import { AGENDA_API_URL } from "../utils/constants";

export async function getContacts(): Promise<IContact[]> {
  const contactsFetched = await fetch(AGENDA_API_URL, {method: 'GET'});
  const contacts: IContact[] = await contactsFetched.json();
  return contacts;
}

export async function getContactById(id: number): Promise<IContact> {
  const contactFetched = await fetch(`${AGENDA_API_URL}/${id}`, {method: 'GET'});
  const contact: IContact = await contactFetched.json();
  return contact;
}

export async function deleteContact(id: number): Promise<Response> {
  return await fetch(`${AGENDA_API_URL}/${id}`, {method: 'DELETE'});
}

export async function updateContact(id: number, contact: IContact): Promise<Response> {
  return await fetch(`${AGENDA_API_URL}/${id}`, {
    method: 'PATCH',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(contact)
  });
}

export async function insertContact(contact: IContact): Promise<Response> {
  return await fetch(AGENDA_API_URL, {
    method: 'POST', 
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(contact) 
  });
}
