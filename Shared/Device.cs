using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWOL.Shared
{
    public class Device
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "デバイス名を入力してください。")]
        [StringLength(20, ErrorMessage = "デバイス名は20文字までです。")]
        public string Name { get; set; }

        [Required(ErrorMessage = "MACアドレスを入力してください。")]
        [RegularExpression(@"(?i)^[\da-f]{2}((:|-)[\da-f]{2}){5}$", ErrorMessage = "MACアドレスの書式が正しくありません。")]
        public string MACAddress { get; set; }
    }
}
