import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { cn } from "@/lib/utils";

export function SignInPage(): JSX.Element {
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
          />
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
            type="password"
          />
        </div>
        <Button
          className="w-full bg-blue-600 hover:bg-blue-500"
        >
          Entrar
        </Button>
      </form>
    </div>
  );
}