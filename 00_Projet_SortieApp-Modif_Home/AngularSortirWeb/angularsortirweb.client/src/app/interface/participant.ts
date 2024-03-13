/**
 * <b><code>Participant</code></b>
 * @param id number | null
 * @param login string
 * @param role Role
 * @param email string
 * @param lastName string
 * @param firstName string
 * @param password string
 */
import {Role} from "./role";

export interface Participant {
  Id: number | null;
  Nom: string;
  Prenom: string;
  Mail: string;
  RoleId: number;
  
  role: Role;
}
