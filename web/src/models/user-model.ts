import { z } from "zod";

export const UserProps = z.object({
  id: z.number().int().positive(),
  login: z.string(),
  name: z.string(),
  createdAt: z.string().datetime(),
  updatedAt: z.string().datetime().nullable(),
  deletedAt: z.string().datetime().nullable(),
});

export class UserModel {
  private id: number;
  private login: string;
  private name: string;
  private createdAt: Date;
  private updatedAt: Date | null;
  private deletedAt: Date | null;

  constructor({ id, login, name, createdAt, updatedAt, deletedAt }: z.infer<typeof UserProps>) {
    this.id = id;
    this.login = login;
    this.name = name;
    this.createdAt = new Date(createdAt);
    this.updatedAt = updatedAt ? new Date(updatedAt) : null;
    this.deletedAt = deletedAt ? new Date(deletedAt) : null;
  }

  public getId(): number {
    return this.id;
  }

  public getLogin(): string {
    return this.login;
  }

  public getName(): string {
    return this.name;
  }

  public getCreatedAt(): Date {
    return this.createdAt;
  }

  public getUpdatedAt(): Date | null {
    return this.updatedAt;
  }

  public getDeletedAt(): Date | null {
    return this.deletedAt;
  }
}