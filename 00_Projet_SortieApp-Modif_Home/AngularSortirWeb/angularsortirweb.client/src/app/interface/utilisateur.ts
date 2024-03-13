/**
 * <b><code>User</code></b>
 * @param id number | null
 * @param login string
 * @param role Role
 * @param email string
 * @param lastName string
 * @param firstName string
 * @param password string
 */
import {Role} from "./role";

export interface Utilisateur {
  Id: number | null;
  Username: string;
  Password: string;
  LastName: string;
  FirstName: string;
  Mail: string;
  Role: Role;
}
