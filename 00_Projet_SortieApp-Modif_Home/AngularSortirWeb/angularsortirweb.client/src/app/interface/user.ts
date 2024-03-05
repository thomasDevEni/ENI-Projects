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

export interface User {
  id: number | null;
  username: string;
  role: Role;
  email: string;
  lastname: string;
  firstname: string;
  password: string;
}
