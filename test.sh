for path in */; do
    [ -d "${path}" ] || continue # if not a directory, skip
    [[ "$(basename "${path}")" == .* ]] && continue
    dirname="$(basename "${path}")"
    cd "$dirname" || exit
    dotnet test
    cd .. || exit
done