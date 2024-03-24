import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { cn } from "@/lib/utils";
import { useState } from "react";

export function SignInPage(): JSX.Element {
  const [login, setLogin] = useState<string>("");
  const [validLogin, setValidLogin] = useState<boolean>(true);

  const [password, setPassword] = useState<string>("");
  const [validPassword, setValidPassword] = useState<boolean>(true);
  const [passwordVisible, setPasswordVisible] = useState<boolean>(false);

  return (
    <div
      className={cn(
        "w-full h-full bg-gradient-to-b from-slate-900 to-black",
        "flex items-center justify-center"
      )}
    >
      <form
        className="w-96 bg-slate-800 space-y-4 p-4 rounded shadow"
      >
        <div>
          <Label
            htmlFor="login"
            className="text-white"
          >
            Login
          </Label>
          <Input
            id="login"
            className={cn(
              "bg-slate-700 text-white ring-offset-0 focus-visible:ring-offset-0 focus-visible:ring-0",
              "border-transparent border-2",
              validLogin ? "focus-visible:border-blue-500" : "border-red-500"
            )}
            onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
              const text: string = e.target.value;

              setLogin(text);
              setValidLogin(text.length > 0);
            }}
            onBlur={(e: React.FocusEvent<HTMLInputElement>) => {
              const text: string = e.target.value;

              setValidLogin(text.length > 0);
            }}
          />
          {!validLogin && (
            <span
              className="text-red-500 text-xs"
            >
              Campo obrigatório
            </span>
          )}
        </div>
        <div>
          <Label
            htmlFor="password"
            className="text-white"
          >
            Senha
          </Label>
          <Input
            id="password"
            type={passwordVisible ? "text" : "password"}
            className={cn(
              "bg-slate-700 text-white ring-offset-0 focus-visible:ring-offset-0 focus-visible:ring-0",
              "border-transparent border-2",
              validPassword ? "focus-visible:border-blue-500" : "border-red-500"
            )}
            onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
              const text: string = e.target.value;

              setPassword(text);
              setValidPassword(text.length > 0);
            }}
            onBlur={(e: React.FocusEvent<HTMLInputElement>) => {
              const text: string = e.target.value;

              setValidPassword(text.length > 0);
            }}
          />
          {!validPassword && (
            <span
              className="text-red-500 text-xs"
            >
              Campo obrigatório
            </span>
          )}
        </div>
        <Button
          className="w-full bg-blue-600 hover:bg-blue-500"
          type="submit"
          disabled={!validLogin || !validPassword || login.length === 0 || password.length === 0}
        >
          Entrar
        </Button>
      </form>
    </div>
  );
}