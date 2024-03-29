import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
import { Button } from "@/components/ui/button";
import { Checkbox } from "@/components/ui/checkbox";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { AlertVariantEnum } from "@/enums";
import { cn } from "@/lib/utils";
import { SignInResponse } from "@/responses";
import { AuthService } from "@/services";
import { useMutation } from "@tanstack/react-query";
import { X } from "lucide-react";
import { useState } from "react";

export function SignInPage(): JSX.Element {
  const [login, setLogin] = useState<string>("");
  const [validLogin, setValidLogin] = useState<boolean>(true);

  const [password, setPassword] = useState<string>("");
  const [validPassword, setValidPassword] = useState<boolean>(true);
  const [passwordVisible, setPasswordVisible] = useState<boolean>(false);

  const [alertOpen, setAlertOpen] = useState<boolean>(false);
  const [alertMessage, setAlertMessage] = useState<string>("");
  const [alertVariant, setAlertVariant] = useState<AlertVariantEnum>(AlertVariantEnum.DEFAULT);

  const { mutate, isPending } = useMutation({
    mutationKey: ["sign-in"],
    mutationFn: async (e: React.FormEvent<HTMLFormElement>) => {
      try {
        e.preventDefault();

        const signInResponse: SignInResponse = await AuthService.signIn(login, password);

        console.log(signInResponse);
      } catch (error: any) {
        console.log(error);

        setAlertMessage(error.message || "Erro inesperado ao realizar login.");
        setAlertVariant(error.variant || AlertVariantEnum.ERROR);
        setAlertOpen(true);
      }
    }
  });

  function closeAlert(): void {
    setAlertOpen(false);
    setAlertMessage("");
    setAlertVariant(AlertVariantEnum.DEFAULT);
  }

  return (
    <div
      className={cn(
        "w-full h-full bg-gradient-to-b from-slate-900 to-black",
        "flex flex-col items-center justify-center"
      )}
    >
      {alertOpen && (
        <Alert
          variant={alertVariant}
          className="w-96 mb-4"
        >
          <AlertTitle className="flex items-center justify-end">
            <X
              className={cn(
                "hover:bg-slate-900 rounded-full cursor-pointer p-1",
                "transition-colors duration-200 ease-in-out"
              )}
              onClick={closeAlert}
            />
          </AlertTitle>
          <AlertDescription>{alertMessage}</AlertDescription>
        </Alert>
      )}
      <form
        className="w-96 bg-slate-800 space-y-4 p-4 rounded shadow"
        onSubmit={mutate}
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
          <div
            className="flex items-center space-x-2 text-white text-sm pt-2"
          >
            <Checkbox
              className="border-white"
              id="show-password"
              checked={passwordVisible}
              onCheckedChange={() => {
                setPasswordVisible(!passwordVisible);
              }}
            />
            <Label
              htmlFor="show-password"
              className="cursor-pointer"
            >
              Mostrar senha
            </Label>
          </div>
        </div>
        <Button
          className="w-full bg-blue-600 hover:bg-blue-500"
          type="submit"
          disabled={!validLogin || !validPassword || login.length === 0 || password.length === 0 || isPending}
        >
          Entrar
        </Button>
      </form>
    </div>
  );
}