for path in */; do
    [ -d "${path}" ] || continue # if not a directory, skip
    [[ "$(basename "${path}")" == .* ]] && continue
    dirname="$(basename "${path}")"
    cd "$dirname" || exit
    exercise_name=${path::-1}
    file_name=${file_name//-/_}
    dotnet test
    cd .. || exit
done