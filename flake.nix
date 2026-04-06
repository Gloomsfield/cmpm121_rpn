{
	description = "CMPM 121 - RPN development environment";

	inputs = {
		nixpkgs.url = "github:nixos/nixpkgs?ref=nixos-unstable";
	};

	outputs = { self, nixpkgs }:
	let
		pkgs = import nixpkgs { system = "aarch64-linux"; };

		lib = nixpkgs.lib;

		collapse_multiline = { separator, string }:
			let
				split_string = lib.strings.splitString "\n" string;
				trim_string = line: lib.strings.trimWith { start = true; end = true; } line;
				string_array = map (line: trim_string line) split_string;
				out = lib.strings.concatStringsSep separator string_array;
			in out;
	in {
		devShells.aarch64-linux.default = pkgs.mkShell.override { stdenv = pkgs.clangStdenv; } {
			name = "CMPM 121 - RPN";

			buildInputs = with pkgs; [
				# BUILD TOOLS #
				dotnet-sdk

				# LIBRARIES #
			];

			env = { };
		};
	};
}
