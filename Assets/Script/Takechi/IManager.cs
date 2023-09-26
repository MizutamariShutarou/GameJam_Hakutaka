interface IManager
{
    /// <summary>問題に正解したときに呼び出される</summary>
    void Correct();
    /// <summary>問題を間違えたときに呼び出される</summary>
    void Incorrect();
    /// <summary>初期化するときに呼び出す</summary>
    void Initialize();
}
